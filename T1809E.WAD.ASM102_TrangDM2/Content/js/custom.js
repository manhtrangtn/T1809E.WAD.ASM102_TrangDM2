$( document ).ready(function() {
});
$(document).bind('ajaxStart', function () {
    $("#loadedContent").html("<img src='https://miro.medium.com/max/1600/1*CsJ05WEGfunYMLGfsT2sXA.gif'>");
}).bind('ajaxComplete', function () {
});
function LoadModal(id, url) {
    $.ajax({
        url: url,
        type: "get",
        data: {
            id: id
        },
        success: (res) => {
            $("#loadedContent").html(res);
        },
        error: (e) => {
            console.log("1");
        }
    });
}

function GetFunction(url) {
    $.ajax({
        url: url,
        type: "get",
        success: (res) => {
            $("#loadedContent").html(res);
            $("#modal1").openModal();
        },
        error: (e) => {
            console.log("0");
        }
    });
}

function AddToCart(id, quantity) {
    $.ajax({
        url: "Cart/Add",
        type: "Get",
        data: {
            id: id,
            quantity: quantity
        },
        success: (res) => {
            swal({
                title: "Success",
                text: "Your cart has been added.",
                type: "success",
                timer: 1200,
                showConfirmButton: false
            });
            console.log(1);
        },
        error: (e) => {
            console.log(e);
        }
    });
}

function Add(id,quantity) {
    AddToCart(id, quantity);
    ViewCart();
}
function Minus(id, quantity) {
    AddToCart(id, quantity);
    ViewCart();
}

function Delete(id) {
    $.ajax({
        url: "Cart/Delete",
        type: "Get",
        data: {
            id: id
        },
        success: (res) => {
            Materialize.toast("Delete successfully", 3000);
            ViewCart();
        },
        error: (e) => {
            Materialize.toast("Failed", 3000);
        }
    });
}
function ViewCart() {
    $.ajax({
        url: "Cart/ShowCart",
        type: "Get",
        success: (res) => {
            $("#loadedContent").html(res);
            $("#modal1").openModal();
        },
        error: (e) => {
            Materialize.toast("Failed",3000);
        }
    });
}
function ConfirmDelete(id) {
    swal({
        title: "Are you sure to delete?",
        text: "You will not be able to recover this!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        console.log(id);
        $.post({
            url: "/Products/Delete",
            data: {
                id: id
            },
            success: (res) => {
                location.reload(true);
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            },
            error: (e) => {
                swal("Failed!", "Your imaginary file is safe :)", "error");
            }
        });
    });
}

function LoadProduct(pageNum) {
    
    $.ajax({
        url: "Products/PagingIndex",
        type: "get",
        data: {
            keyword: $("#searchKeyword").val(),
            categoryId: $("#category_id").val(),
            pageNum: pageNum,
            pageSize: $("#pageSize").val()
        }, 
        success: (res) => {
            $("#product_content").html(res);
        },
        error: (e) => {
            console.log(e);
        }
    });
}