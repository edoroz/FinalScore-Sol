

$(document).ready(function () {
    CargarEquipos();
});

function CargarEquipos() {

    fetch("/admin/equipos/GetAll")
        .then(response => response.json())
        .then(result => {
            const equipos = result.data;
            const list = document.getElementById("equipoList");
            const titles = document.createElement("div");
            titles.textContent = 'Equipo\t\tParque\t\t\tCiudad\t\t\tLiga\t\t\tDesc';
            list.appendChild(titles);

            equipos.forEach(equipo => {
                const item = document.createElement("div");
                item.textContent = `${equipo.nombre}\t${equipo.parque}\t\t${equipo.ciudad}\t\t${equipo.liga}\t\t${equipo.pais}`;
                list.appendChild(item);
            });
        })
        .catch(error => console.error("Error loading equipos:", error));
}