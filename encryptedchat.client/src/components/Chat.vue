<template>
    <div>
    <div>
        <div>
            <input type="text" id="username" placeholder="Your name...">
            <div>
                <button onclick="onClearCache()">Clear Cache</button>
            </div>
        </div>
    </div>
    <div id="chatBox">
        @foreach (var message in Model.GetMessageCache())
        {
            <div>
                <p><strong>@(message.User)</strong>: @message.Message<span class="float-right small font-italic">@message.Time</span></p>
            </div>            
        }
    </div>
    <div>
        <div>
            <input type="text" id="message" placeholder="Type your message...">
            <div>
                <button id="sendButton">Send</button>
            </div>
        </div>
    </div>
</div>
</template>

<script>

export default {
    install(Vue) {        
        const connection = new HubConnectionBuilder()
          .withUrl(`${Vue.prototype.$http.defaults.baseURL}/chatHub`) 
          .configureLogging(LogLevel.Information)
          .build();        

        const userHub = new Vue();

        Vue.prototype.$userHub = userHub;

        connection.on("AddUserEvent", (userId, userName) => {
          userHub.$emit("user-added-event", { userId, userName });
        });

        // if connection closed, reopen it
        let startedPromise = null;

        function start() {
          startedPromise = connection.start().catch(err => {
            return new Promise((resolve, reject) =>
              setTimeout(
                () =>
                  start()
                    .then(resolve)
                    .catch(reject), 5000
              )
            );
          });
          return startedPromise;
        }

        connection.onclose(() => start());

        start();
    },

    created() {
        this.$socket.start({ log: true })
        this.$userHub.$on("user-added-event", this.userAddedEvent);
    },

    beforeDestroy() {
        //clean SignalR event
        this.$userHub.$off("user-added-event", this.userAddedEvent);
    },

    sockets: {
    },

    components: {
    },

    props: {
    },

    data() {
        return {
            connection: null,
        }
    },

    methods: {
    }
}

</script>