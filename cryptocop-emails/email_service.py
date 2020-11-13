import pika
import requests
import json


connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
channel = connection.channel()
exchange_name = 'order'
create_order_routing_key = 'create-order'
queue_name = 'email-queue'


# Declare the exchange, if it doesn't exist
channel.exchange_declare(exchange=exchange_name, exchange_type='fanout')
# Declare the queue, if it doesn't exist
#channel.queue_declare(queue=queue_name, durable=False)
# Bind the queue to a specific exchange with a routing key
channel.queue_bind(exchange=exchange_name, queue=queue_name, routing_key=create_order_routing_key)

class Order:
    def __init__(self, Id, Email, FullName, StreetName, HouseNumber, ZipCode, Country, City, CardholderName, CreditCard, OrderDate, TotalPrice, OrderItems):
        self.Id = Id
        self.Email = Email
        self.FullName = FullName
        self.StreetName = StreetName
        self.HouseNumber = HouseNumber
        self.ZipCode = ZipCode
        self.Country = Country
        self.City = City
        self.CardholderName = CardholderName
        self.CreditCard = CreditCard
        self.OrderDate = OrderDate
        self.TotalPrice = TotalPrice
        self.OrderItems = OrderItems
        


print("The program is running...")

def send_simple_message(to, subject, body):
    return requests.post(
        "https://api.mailgun.net/v3/sandbox0c64dea78725467ab85b4cb1d5227c89.mailgun.org/messages",
        auth=("api", "b28775022a6e17f9325f37afa95ca720-53c13666-d6639a1b"),
        data={"from": "Mailgun Sandbox <postmaster@sandbox0c64dea78725467ab85b4cb1d5227c89.mailgun.org>",
              "to": to,
              "subject": subject,
              "html": body})

def send_order_email(ch, method, properties, data):
    print("Data recieved from RabbitMQ")
    parsed_msg = json.loads(data)
    order = Order(**parsed_msg)
    
    ##get info from object
    recipient = str(order.Email)
    fullName = order.CardholderName
    streetName = order.StreetName
    houseNumber = order.HouseNumber
    city = order.City
    zipCode = order.ZipCode
    country = order.Country
    date = order.OrderDate
    price = order.TotalPrice

    print(recipient)

    fullNameHTML = '<p> Name: ' + fullName + '</p> </br>'
    addressHTML = '<p> Address: ' + streetName + houseNumber + '</p> </br>'
    cityHTML = '<p> City: ' + city + '</p> </br>'
    zipCodeHTML = '<p> Zip Code: ' + zipCode + '</p> </br>'
    countryHTML = '<p> Country: ' + country + '</p> </br>'
    dateHTML = '<p> Date of order: ' + date + '</p> </br>'
    priceHTML = '<p> Total price: ' + str(price) + '$</p> </br>'

    email_greeting = '<h2>Thank you for ordering from CryptoCop!</h2><h3>The following is a copy of your order:</h3></br>'
    email_template = email_greeting + fullNameHTML + addressHTML + cityHTML + zipCodeHTML + countryHTML + dateHTML + priceHTML

    send_simple_message(recipient, 'Your order from CryptoCop (sindrii17)', email_template)
    print("Email successfully sent")

channel.basic_consume(
    queue=queue_name, on_message_callback=send_order_email, auto_ack=True)

channel.start_consuming()
connection.close()
