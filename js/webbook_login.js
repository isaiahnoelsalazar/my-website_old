function login(){
    let requestLogin = new XMLHttpRequest();
    requestLogin.open("GET", `https://sasasaia.pythonanywhere.com/login?username=${document.getElementById("username").value}&password=${document.getElementById("password").value}`, true);
    requestLogin.withCredentials = true;
    requestLogin.onreadystatechange = function (){
        if (requestLogin.status == 200 && requestLogin.readyState == 4){
            let response = requestLogin.responseText;
            if (response == "Failed"){
            } else {
                if (response.split(":")[0] == "Success"){
                    window.location.href = "webbook.html";
                }
            }
        }
    }
    requestLogin.send();
}