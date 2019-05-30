document.addEventListener('DOMContentLoaded', () => {

    let getItems = async () => {
        const itemsRaw = await fetch("https://localhost:44390/api/xml", {
            cache: "no-cache",
            method: "GET"
        });
        const items = await itemsRaw.json();

        console.log(items);
        
        var textedJson = JSON.stringify(items, undefined, 4);
        var element = document.getElementById("myData");
        element.innerText = textedJson;

    };

    getItems();

    btnAddToDb.addEventListener("click", async () => {
        (async () => {
            const rawResponse = await fetch('https://localhost:44390/api/xml', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                 body: JSON.stringify("add")
            });
            const content = await rawResponse.json();

            console.log(content);
            var element = document.getElementById("response");
            element.innerText = "Response: "+ content;

        })();
    });

});