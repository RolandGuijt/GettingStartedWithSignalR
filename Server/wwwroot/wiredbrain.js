listen = (id) => {
    var eventSource = new EventSource(`/Coffee/GetUpdateForOrder/${id}`);
    eventSource.addEventListener("message", function (event) {
        const data = JSON.parse(event.data);
        
    }, false);
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
        .then(text => listen(id));
});