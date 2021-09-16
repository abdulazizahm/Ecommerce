function uploadImage() {
    let input = document.getElementById('imageFile');
    if (input.files && input.files[0]) {

        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                console.log(xhttp.responseText);
                document.getElementById('img').src = xhttp.responseText;
            }
        };
        xhttp.open("POST", "/Image/upload", true);
        var formData = new FormData(document.getElementById('imageForm'));
        xhttp.send(formData);
    }
}


function addToCart(productId) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            let cartBadge = document.getElementById('cartBadge');
            cartBadge.innerHTML = xhttp.responseText;
            cartBadge.classList.add('qty');
        }
    };
    xhttp.open("POST", "/Cart/AddToCart", true);
    var formData = new FormData();
    formData.append("id", productId);
    xhttp.send(formData);
}




function deleteFromCard(id) {
    $('#' + id).fadeOut();
    $("#bill_" + id).fadeOut();

    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            let total = document.getElementById('order-total');
            total.innerHTML = xhttp.responseText;
            let cartBadge = document.getElementById('cartBadge');

            if ((parseInt(cartBadge.innerHTML)) > 1) {
                cartBadge.innerHTML = parseInt(cartBadge.innerHTML) - 1;
            }
            else {
                cartBadge.innerHTML = "";
                cartBadge.classList.remove('qty');
                document.getElementById('order-submit').classList.add('disabled');
            }
        }
    };
    xhttp.open("POST", "/Cart/Remove");
    var formData = new FormData();
    formData.append("id", id);
    xhttp.send(formData);
}