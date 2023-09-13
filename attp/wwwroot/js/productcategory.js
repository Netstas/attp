$(document).ready(function () {
    $(".delete-category").click(function () {
        var categoryId = $(this).data("category-id");
        var productName = $(this).closest("tr").find("td:first-child").text();

        if (confirm(`Xác nhận xoá ?`)) {
            $.ajax({
                url: "@Url.Action("DeleteProductCategories", "Admin")",
                type: "POST",
                data: { id: categoryId },
                success: function (result) {
                    location.reload();
                },
                error: function (error) {
                    alert("An error occurred while deleting the product.");
                }
            });
        }
    });
});