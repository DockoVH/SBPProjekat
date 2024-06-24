async function popuniOdeljenja() {
    const data = await fetch("https://localhost:7234/Odeljenje/PruzmiSvaOdeljenja");
    const odeljenja = await data.json();

    const tbody = document.querySelector("table>tbody");

    let i = 1;

    for (let o of odeljenja) {
        const row = document.createElement("tr");
        tbody.appendChild(row);

        const cellId = document.createElement("td");
        cellId.innerText = i++;
        row.appendChild(cellId);

        const cell1 = document.createElement("td");
        cell1.innerText = o.odeljenjeId;
        row.appendChild(cell1);

        const cell2 = document.createElement("td");
        cell2.innerText = o.lokacija;
        row.appendChild(cell2);

        const cellBK = document.createElement("td");
        cellBK.innerText = o.brojKasa;
        row.appendChild(cellBK);

        const cellIP = document.createElement("td");
        cellIP.innerText = o.infoPult;
        row.appendChild(cellIP);

        const cell3 = document.createElement("td");
        cell3.innerText = o.nazivProdavnice;
        row.appendChild(cell3);

        const cell4 = document.createElement("td");
        cell4.innerText = o.tipOdeljenja;
        row.appendChild(cell4);
    }
}

async function kreirajProdavnice() {
    const data = await fetch("https://localhost:7234/Prodavnica/PreuzmiProdavnice");
    const prodavnice = await data.json();

    for (let p of prodavnice) {
        const prodavnica = document.querySelector("#prodavnica");
        const option = document.createElement("option");
        option.innerText = p.naziv + ` (${p.adresa})`;
        option.value = p.id;
        prodavnica.appendChild(option);
    }
}

async function kreirajOdeljenja() {
    const data = await fetch("https://localhost:7234/Odeljenje/PruzmiSvaOdeljenja");
    const odeljenja = await data.json();

    for (let o of odeljenja) {
        const prodavnica = document.querySelector("#odeljenje");
        const option = document.createElement("option");
        option.innerText = o.tipOdeljenja + ` (${o.odeljenjeId})`;
        option.value = o.odeljenjeId;
        prodavnica.appendChild(option);
    }
}

async function dodajOdeljenje() {
    const prodavnicaID = document.querySelector("#prodavnica").value;

    let podaci = {
        lokacija: document.querySelector("#lokacija").value,
        brojKasa: parseInt(document.querySelector("#brojkasa").value),
        infoPult: document.querySelector("#infopult").value
    };

    const data = await fetch(`https://localhost:7234/Odeljenje/KreirajOdeljenjeDo5/${prodavnicaID}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(podaci)
    });

    if (data.ok) {
        alert("Uspeo upis odeljenja.");
    }
}

async function azurirajOdeljenje() {
    let podaci = {
        odeljenjeId: parseInt(document.querySelector("#odeljenje").value),
        lokacija: document.querySelector("#lokacija").value,
        brojKasa: parseInt(document.querySelector("#brojkasa").value),
        infoPult: document.querySelector("#infopult").value
    };

    const data = await fetch(`https://localhost:7234/Odeljenje/IzmenaOdeljenja`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(podaci)
    });

    if (data.ok) {
        alert("Uspela izmena odeljenja.");
    }
}

async function obrisiOdeljenje() {
    let odeljenjeId = parseInt(document.querySelector("#odeljenje").value);

    const data = await fetch(`https://localhost:7234/Odeljenje/IzbrisiOdeljenje/${odeljenjeId}`, {
        method: "DELETE"
    });

    if (data.ok) {
        alert("Uspelo brisanje odeljenja.");
    }
}