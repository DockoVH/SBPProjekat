import { Prodavnica } from "./prodavnica.js";

export class RadiU {
    constructor(url, container) {
        this.url = url;
        this.container = container;
    }

    async loadData() {
        const f = await fetch(this.url);
        this.data = await f.json();
        this.clearBody();
        await this.showData(this.container);
    }

    columnNameToHeader(columnName) {
        columnName = columnName.slice(0, 1).toUpperCase() + columnName.slice(1);
        return columnName.replace(/([A-Z]+)/g, ' $1').replace(/^ /, '')
    }

    clearBody() {
        const lista = document.body.childNodes;
        for (var i = lista.length - 1; i >= 0 ;i--){
            document.body.removeChild(lista[i]);
        }
    }

    async showData(container) {
        const table = document.createElement("table");
        table.classList.add("table", "table-hover", "table-striped");
        container.appendChild(table);
        const thead = document.createElement("thead");
        thead.classList.add("bg-primary", "text-white");
        table.appendChild(thead);
        const tbody = document.createElement("tbody");
        table.appendChild(tbody);

        if (this.data.length > 0) {
            for (const a in this.data[0]) {
                if (a == "id") {
                    const th = document.createElement("th");
                    th.classList.add("text-center");
                    th.innerHTML = "Radnik";
                    thead.appendChild(th);
                    const th2 = document.createElement("th");
                    th2.classList.add("text-center");
                    th2.innerHTML = "Prodavnica";
                    thead.appendChild(th2);
                }
                else {
                    const th = document.createElement("th");
                    th.classList.add("text-center");
                    th.innerHTML = this.columnNameToHeader(a);
                    thead.appendChild(th);
                }
            }

            for (const d of this.data) {
                const tr = document.createElement("tr");
                tbody.appendChild(tr);

                for (const c in d) {
                    if (c == "id") {
                        const td = document.createElement("td");
                        td.innerHTML = d[c].radnikRadiU.jbr + ` (${d[c].radnikRadiU.ime} ${d[c].radnikRadiU.srednjeSlovo}. ${d[c].radnikRadiU.prezime})`;
                        td.classList.add("text-center");
                        tr.appendChild(td);
                        const td2 = document.createElement("td");
                        td2.innerHTML = d[c].radiUProdavnica.id + ` (${d[c].radiUProdavnica.naziv})`;
                        td2.classList.add("text-center");
                        tr.appendChild(td2);
                    }
                    else {
                        const td = document.createElement("td");
                        td.innerHTML = d[c];
                        td.classList.add("text-center");
                        tr.appendChild(td);
                    }
                }
            }
        }
        else {
            const p = document.createElement("p");
            p.innerText = "Nema podataka!";
            container.appendChild(p);
        }

        const button = document.createElement("button");
        container.appendChild(button);
        button.textContent = "Vrati na prodavnice";
        button.onclick = async () => {
            const prodavnica = new Prodavnica("https://localhost:7234/Prodavnica/PreuzmiProdavnice", this.container);
            await prodavnica.loadData();
        };
    }
}