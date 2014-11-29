var chatDb = require('./data/chat-db');

chatDb.init('localhost:27017/chat');

function registerUsers() {
    chatDb.registerUser({ username: 'Pesho', password: 123456 });
    chatDb.registerUser({ username: 'Gosho', password: 123456 });
}

function sendMessages() {
    chatDb.sendMessage({
        from: 'Pesho',
        to: 'Gosho',
        text: 'Hello.'
    });
    
    chatDb.sendMessage({
        from: 'Gosho',
        to: 'Pesho',
        text: 'How are you?'
    });
}

function getMessages() {
    chatDb.getMessages({ with: 'Pesho', and: 'Gosho' }, function (results) {
        for (var i = 0; i < results.length; i += 1) {
            console.log(results[i].text);
        }
    });
}

registerUsers();
setTimeout(sendMessages, 1000);
setTimeout(getMessages, 1000);