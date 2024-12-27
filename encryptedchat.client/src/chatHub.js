import { HubConnectionBuilder } from "@microsoft/signalr";

class chatHub {
    constructor() {
        this.client = new HubConnectionBuilder()
        .withUrl("/chatHub")
        .build();
    }

    start() {
        this.client.start();
    }
}

export default new chatHub();
