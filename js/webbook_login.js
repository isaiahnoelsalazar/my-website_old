function login(){
    let requestLogin = new XMLHttpRequest();
    requestLogin.open("GET", `https://sasasaia.pythonanywhere.com/login?username=${document.getElementById("username").value}&password=${document.getElementById("password").value}`, true);
    requestLogin.onreadystatechange = function (){
        let response = requestLogin.responseText;
        document.write(response);
        if (requestLogin.status == 200 && requestLogin.readyState == 4){
            let response = requestLogin.responseText;
            if (response == "Failed"){
            } else {
                /*let value = response.split(":")[1];
                if (response.split(":")[0] == "Success"){
                    window.location.href = `webbook.html?uid=${value}`;
                }
                let value = response.split(":")[1];*/
                if (response.split(":")[0] == "Success"){
                    //window.location.href = "webbook.html";
                }
            }
        }
    }
    requestLogin.send();
}