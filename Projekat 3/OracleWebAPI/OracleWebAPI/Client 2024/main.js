import { Prodavnica } from "./prodavnica.js";

const prodavnica = new Prodavnica("https://localhost:7234/Prodavnica/PreuzmiProdavnice", document.body);
await prodavnica.loadData();