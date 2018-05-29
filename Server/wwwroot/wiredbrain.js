let intervalId;

poll = (orderId) => {
    fetch(`/Coffee/${orderId}`)
        .then(response => {
                if (response.status === 200) {
                    const statusDiv = document.getElementById("status");
                    response.json().then(j => {
                        statusDiv.innerHTML = j.update;
                        if (j.finished)
                            clearInterval(intervalId);
                    });
                }
            }
        );
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
        .then(text => intervalId = setInterval(poll, 1000, text));
});