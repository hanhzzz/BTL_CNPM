$(document).ready(function () {
    // Activate tooltip
    $('[data-toggle="tooltip"]').tooltip();

    // Select/Deselect checkboxes
    var checkbox = $('table tbody input[type="checkbox"]');
    $("#selectAll").click(function () {
        if (this.checked) {
            checkbox.each(function () {
                this.checked = true;
            });
        } else {
            checkbox.each(function () {
                this.checked = false;
            });
        }
    });
    checkbox.click(function () {
        if (!this.checked) {
            $("#selectAll").prop("checked", false);
        }
    });
});

$(function () {
    // ON SELECTING ROW
    $(".gfgselect").click(function () {
        //FINDING ELEMENTS OF ROWS AND STORING THEM IN VARIABLES
        var a =
            $(this).parents("tr").find(".mtaikhoan").text();
        var b =
            $(this).parents("tr").find(".taikhoan").text();
        var c =
            $(this).parents("tr").find(".matkhau").text();
        var d =
            $(this).parents("tr").find(".tinhtrang").text();
        $("#exampleInputMTaikhoan").val(a)
        $("#exampleInputTaikhoan").val(b)
        $("#exampleInputMK").val(c)
        $("#exampleInputTT").val(d)
    });
});

$(function () {
    // ON SELECTING ROW
    $(".gfgselect").click(function () {
        //FINDING ELEMENTS OF ROWS AND STORING THEM IN VARIABLES
        var a =
            $(this).parents("tr").find(".mtaikhoan").text();
        var b =
            $(this).parents("tr").find(".taikhoan").text();
        var c =
            $(this).parents("tr").find(".matkhau").text();
        var d =
            $(this).parents("tr").find(".tinhtrang").text();
        $("#exampleInputMTaikhoan").val(a)
        $("#exampleInputSTaikhoan").val(a)
        $("#exampleInputTaikhoan").val(b)
        $("#exampleInputMK").val(c)
        $("#exampleInputTT").val(d)
    });
});