
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'
// import VueSocketIO from 'vue-socket.io'

// "async" is optional
export default ({ Vue }) => {
    const connection = new HubConnectionBuilder()
        .withUrl('http://localhost:5000/myhub')
        .configureLogging(LogLevel.Information)
        .build()

    connection.start()

    Vue.prototype.$connection = connection
}
