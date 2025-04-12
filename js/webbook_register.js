function register(){
    let requestRegister = new XMLHttpRequest();
    requestRegister.open("POST", `https://sasasaia.pythonanywhere.com/register?username=${document.getElementById("username").value}&password=${document.getElementById("password").value}`, true);
    requestRegister.onreadystatechange = function (){
        if (requestRegister.status == 200 && requestRegister.readyState == 4){
            let response = requestRegister.responseText;
            if (response == "Success"){
                window.location.href = "webbook_login.html";
            }
        }
    }
    requestRegister.send();
}