const amqp = require('amqplib/callback_api');
const valid = require("card-validator");


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
    channel.assertQueue(queues.PaymentQueue, { durable: true });
    channel.bindQueue(queues.PaymentQueue, exchanges.order, routingKeys.validateCard);
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
   
    const { PaymentQueue } = messageBrokerInfo.queues;

    channel.consume(PaymentQueue, async (data) =>{

        //read from buffer
        var JSONData = JSON.parse(data.content.toString())
        var isValid = false;
 
        var numberValidation = valid.number(JSONData);
        
        if (!numberValidation.isPotentiallyValid) {
        renderInvalidCardNumber();
        console.log("The card number is invalid")
        }
        
        if (numberValidation.card) {
        console.log("The card is a valid ", numberValidation.card.type, " card");
        isValid = true;
        }

    }, { noAck: true });
})().catch(e => console.error(e));