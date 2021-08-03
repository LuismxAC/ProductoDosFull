function msgbox(title, icon, message) {
    Swal.fire({
        icon: icon,
        title: title,
        text: message,
        showConfirmButton: false,
        timer: 2500
    })
}

function msgboxr(title, icon, message, destin) {
    Swal.fire({
        icon: icon,
        title: title,
        text: message,
        showConfirmButton: false,
        timer: 2500
    }).then(function () {
        window.location = destin;
    });
}
