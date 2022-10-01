var dtable;
$(document).ready(function () {
    dtable = $('#MyTable').DataTable({
        "ajax": { "url": "/Clothing/AllClothing" },
        "columns": [
            { "data": "name" },
            { "data": 'description' },
            { "data": "price" },
            { "data": "category.name" },
            { "data": "sizeId" },
            { "data": "brand.name" },
            { "data": "country.name" },
            { "data": "color" },
            { "data": "style" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                           <a href="/clothing/CreateUpdate?id=${data}"><i class="bi bi-pencil-square">Edit</i></a>
                        <a onclick=RemoveClothing("/Clothing/Delete/${data}")><i class="bi bi-trash">Delete</i></a>
          ` }
            }
        ]
    });
});
function RemoveClothing(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won`t be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dtable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    })
}