var dataTable;

$(document).ready(function () {
   LoadDataTable();
});

function LoadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "price", "width": "15%" },
            {
                "data": "id", "render":
                    function (data) {
                        return`<div class="w-75 btn-group" role="group">
                            <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-primary mx-2"> Edit</a >

                            <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-danger mx-2"> Delete</a>

                    </div >`

                        
                    },
                    "width": "15%" }




        ]
    });
}