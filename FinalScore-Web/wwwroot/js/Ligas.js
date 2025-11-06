

var dataTable;

$(document).ready(function () {
    //cargarDataTable();
    CargarLigas();
});

function cargarDataTable() {
    dataTable = $('#tblLigas').dataTable({
        "ajax": {
            "url": "/admin/ligas/GetAll",
            "type": "GET",
            "dataType": "json"
        },
        "columns": [
            {"data": "id",      "width": "05%"},
            {"data": "Nombre",  "width": "20%"},
            {"data": "Deporte", "width": "20%"},
            {"data": "Pais",    "width": "20%"},
            {"data": "Nivel",   "width": "20%"},
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Categorias/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-edit"> Editar
                            </a>
                            &nbsp;
                            <div class="text-center">
                            <a onClick=Delete("/Admin/Categorias/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-trash-alt"> Borrar
                            </a>
                        </div>
                        `;
                },
                "width": "15%"
            }
        ],
        "width"     : "100%"
    });
}

function CargarLigas() {

    fetch("/admin/ligas/GetAll")
        .then(response => response.json())
        .then(result => {
            const ligas = result.data;
            const list = document.getElementById("ligaList");

            ligas.forEach(liga => {
                const item = document.createElement("div");
                item.textContent = `${liga.nombre}\t${liga.pais}\t${liga.nivel}\t${liga.ciclo}\t${liga.desc}`;
                list.appendChild(item);
            });
        })
        .catch(error => console.error("Error loading ligas:", error));
}

