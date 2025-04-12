function register(){
    if (document.getElementById("password").value.length < 8){
        let main = document.getElementById("main");
        let p = document.createElement("p");
        p.id = "context-dialog";
        p.innerHTML = "Password must be at least 8 characters long.";
        main.appendChild(p);
        setTimeout(function (){
            main.removeChild(p);
        }, 5000);
    } else {
        let requestRegister = new XMLHttpRequest();
        requestRegister.open("POST", `https://sasasaia.pythonanywhere.com/register?username=${document.getElementById("username").value}&password=${document.getElementById("password").value}`, true);
        requestRegister.onreadystatechange = function (){
            if (requestRegister.status == 200 && requestRegister.readyState == 4){
                let response = requestRegister.responseText;
                if (response == "Success"){
                    window.location.href = "webbook_login.html";
                } else {
                    let main = document.getElementById("main");
                    let p = document.createElement("p");
                    p.id = "context-dialog";
                    p.innerHTML = response;
                    main.appendChild(p);
                    setTimeout(function (){
                        main.removeChild(p);
                    }, 5000);
                }
            }
        }
        requestRegister.send();
    }
}