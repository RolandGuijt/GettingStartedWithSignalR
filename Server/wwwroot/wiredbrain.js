listen = (id) => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/coffeehub")
        .build();

    connection.on("ReceiveCoffeeUpdate", (update) => {
            const statusDiv = document.getElementById("status");
            statusDiv.innerHTML = update;
        }
    );

    connection.start()
        .catch(err => console.error(err.toString()));
}

document.getElementById("submit").addEventListener("click", e => {
    e.preventDefault();
    const product = document.getElementById("product").value;
    const size = document.getElementById("size").value;
    fetch("/Coffee",
        {
            method: "POST",
            body: { product, size }
        })
        .then(response => response.text())
        .then(id => listen(id));
});