class Greeter {
    element: HTMLElement;
    span: HTMLElement;
    timerToken: number;

    constructor(element: HTMLElement) {
        var user = "Jane User";
        this.element = element;
        this.element.innerHTML = nameit(user);
        this.element.innerHTML += "The time is: ";
        this.span = document.createElement("span");
        this.element.appendChild(this.span);
        this.span.innerText += new Date().toUTCString();
    }

    start() {
        this.timerToken = setInterval(() => this.span.innerHTML = new Date().toUTCString(), 500);
    }

    stop() {
        clearTimeout(this.timerToken);
    }

}

function nameit(person) {
    return `Hello, ${person}  `;
};


window.onload = () => {
    var el = document.getElementById("content");
    var greeter = new Greeter(el);
    //greeter.start();
};