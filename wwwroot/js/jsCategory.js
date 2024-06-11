var dataTable;

$(document).ready(function (){
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblDataCate').DataTable({
        "ajax": {
            "url": "/Category/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            {
                "data": "IDCategoria",
                "render": function (data) {
                    return `
                            <div class="btn-group w-55">
                            <a href="/Category/Edit?id=${data}"
                            <i class="bi bi-pencil-circle">Editar</i>
                    
                    `;

                },
                "width": "15%"
            }
        ]
    });
}

