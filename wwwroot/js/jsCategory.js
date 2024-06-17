
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblDataCate').DataTable({
        "ajax": {
            "url": "/Category/getall"
        },
        "columns": [
            { "data": "Nombre", "width": "15%" },
            { "data": "Suspendido", "width": "15%" },
            {
                "data": "IDCategoria",
                "render": function (data) {
                    return `
                            <div class="btn-group w-55">

                                <a href="/Category/Edit?id=${data}"
                                   class="btn btn-primary mx-4"> 
							    <i class="bi bi-pencil-circle"></i>Edit</a>

                                <a onClick=Delete('/Category/Delete/${data}')
                                   class="btn btn-primary mx-4">
							    <i class="bi bi-trash"></i>Delete</a>
                            </div>
                            `;
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(_url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: _url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}