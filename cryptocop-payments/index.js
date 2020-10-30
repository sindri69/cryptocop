const myDB = require('./data/db')
const amqp = require('amqplib/callback_api');


const messageBrokerInfo = {
    exchanges: {
        order: 'payment_exchange'
    },
    queues: {
        PaymentQueue: 'payment_queue'
    },
    routingKeys: {
        validateCard: 'validate_card'
    }
};

const createMessageBrokerConnection = () => new Promise((resolve, reject) => {
    amqp.connect('amqp://localhost', (err, conn) => {
        if (err) { reject(err); }
        resolve(conn);
    });
});

const configureMessageBroker = channel => {
    const { exchanges, queues, routingKeys } = messageBrokerInfo;

    channel.assertExchange(exchanges.order, 'direct', { durable: true });
    channel.assertQueue(queues.OrderQueue, { durable: true });
    channel.bindQueue(queues.OrderQueue, exchanges.order, routingKeys.createOrder);
}

const createChannel = connection => new Promise((resolve, reject) => {
    connection.createChannel((err, channel) => {
        if (err) { reject(err); }
        configureMessageBroker(channel);
        resolve(channel);
    });
});

(async () => {
    const connection = await createMessageBrokerConnection();
    const channel = await createChannel(connection);
   
    const { OrderQueue } = messageBrokerInfo.queues;

    channel.consume(OrderQueue, async (data) =>{
        console.log("myDB", myDB)
        console.log("YOLO")

        //read from buffer
        var JSONData = JSON.parse(data.content.toString())
        
        //create a new order
        email = JSONData.email
        orderDate = Date.now()
        var totalPrice = 0
        for(i = 0; i < JSONData.items.length; i++) {
            var tmp = JSONData.items[i].quantity * JSONData.items[i].unitPrice
            totalPrice += tmp
        }
        
        orderResult = await myDB.Order.create({
            customerEmail: email,
            totalPrice: totalPrice,
            orderDate: orderDate
        })

        //create order items
        for(i = 0; i < JSONData.items.length; i++) {
            await myDB.OrderItem.create({
                description: JSONData.items[i].description,
                quantity: JSONData.items[i].quantity,
                unitPrice: JSONData.items[i].unitPrice,
                rowPrice: JSONData.items[i].quantity * JSONData.items[i].unitPrice,
                orderId: orderResult._id
            })
        }
     

        console.log("order_service:", data.content.toString('utf-8'))
    }, { noAck: true });
})().catch(e => console.error(e));