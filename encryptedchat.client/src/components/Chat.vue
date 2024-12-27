<template>
    <div>
    <div>
        <div>
            <input type="text" id="username" placeholder="Your name...">
        </div>
    </div>
    <div id="chatBox">
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