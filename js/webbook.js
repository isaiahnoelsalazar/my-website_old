window.onload = function (){
    homeclick();
    let requestSession = new XMLHttpRequest();
    requestSession.open("GET", "https://sasasaia.pythonanywhere.com/session", true);
    requestSession.withCredentials = true;
    requestSession.onreadystatechange = function (){
        if (requestSession.status == 200 && requestSession.readyState == 4){
            let response = requestSession.responseText;
            if (response == "Not logged in."){
                window.location.href = "webbook_login.html";
            }
        }
    }
    requestSession.send();
    let requestAllPosts = new XMLHttpRequest();
    requestAllPosts.open("GET", "https://sasasaia.pythonanywhere.com/get-posts", true);
    requestAllPosts.withCredentials = true;
    requestAllPosts.onreadystatechange = function (){
        if (requestAllPosts.status == 200 && requestAllPosts.readyState == 4){
            let response = requestAllPosts.responseText;
            if (response == "Not logged in."){
                window.location.href = "webbook_login.html";
            } else {
                let allposts = response.split("[nln_str]");
                allposts.forEach(one_post => {
                    if (one_post.length > 0){
                        let contentHomePost = document.createElement("div");
                        let contentHomePostAuthor = document.createElement("h3");
                        let contentHomePostContent = document.createElement("div");
                        let contentHomePostContentP = document.createElement("p");
                        let contentHomePostLine = document.createElement("div");
                        let contentHomePostStarContainer = document.createElement("div");
                        let contentHomePostStarContainerImg = document.createElement("img");

                        contentHomePost.classList = "content-home-post";
                        contentHomePostAuthor.classList = "content-home-post-author";
                        contentHomePostAuthor.innerHTML = one_post.split("[sprtr_str]")[1];
                        contentHomePostContentP.innerHTML = one_post.split("[sprtr_str]")[2];
                        contentHomePostContent.classList = "content-home-post-content";
                        contentHomePostContent.appendChild(contentHomePostContentP);
                        contentHomePostLine.classList = "content-home-post-line";
                        contentHomePostStarContainer.classList = "content-home-post-starcontainer";
                        contentHomePostStarContainer.onclick = function (){

                        };
                        contentHomePostStarContainerImg.src = "../resources/star.png";
                        contentHomePostStarContainer.appendChild(contentHomePostStarContainerImg);
                        contentHomePost.appendChild(contentHomePostAuthor);
                        contentHomePost.appendChild(contentHomePostContent);
                        contentHomePost.appendChild(contentHomePostLine);
                        contentHomePost.appendChild(contentHomePostStarContainer);
                        document.getElementById("content-home").appendChild(contentHomePost);
                    }
                });
            }
        }
    }
    requestAllPosts.send();
};
function newpost(){
    window.location.href = "webbook_post.html";
}
function followuser(){
    let requestFollow = new XMLHttpRequest();
    requestFollow.open("POST", `https://sasasaia.pythonanywhere.com/add-user/${document.getElementById("follow-user-input").value}`, true);
    requestFollow.withCredentials = true;
    requestFollow.onreadystatechange = function (){
        if (requestFollow.status == 200 && requestFollow.readyState == 4){
            let response = requestFollow.responseText;
            if (response == "Not logged in."){
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
}
/*
var isfollowuserclicked = false;
function followuser(){
    if (!isfollowuserclicked){
        var req = new XMLHttpRequest();
        req.open("GET", "https://openweb.fwh.is/ow_webbook/followuser.php?user_id=" + document.getElementById("follow-user-input").value, true);
        req.onreadystatechange = function (){
            if (req.status == 200 && req.readyState == 4){
                var res = req.responseText;
                var p = document.createElement("p");
                p.style.animation = "fadeout 5s ease-in";
                p.style.bottom = "32px";
                p.style.padding = "16px 0";
                p.style.position = "fixed";
                p.style.textAlign = "center";
                p.style.visibility = "hidden";
                p.style.width = "100%";
                p.innerHTML = res;
                document.getElementById("content-community").appendChild(p);
                setTimeout(function (){
                    document.getElementById("content-community").removeChild(p);
                }, 5000);
                isfollowuserclicked = false;
            }
        };
        req.send();
        isfollowuserclicked = true;
    }
}
var isstarclicked = false;
function starclick(postid){
	if (!isstarclicked){
        var req = new XMLHttpRequest();
        req.open("GET", "https://openweb.fwh.is/ow_webbook/starpost.php?post_id=" + postid, true);
        req.onreadystatechange = function (){
            if (req.status == 200 && req.readyState == 4){
                var res = req.responseText;
                var ressplit = res.split(":");
                if (ressplit[1] == "yes"){
                    document.getElementById("post-" + ressplit[0]).src = "/ow_webbook/images/star1.png";
                } else {
                    document.getElementById("post-" + ressplit[0]).src = "/ow_webbook/images/star0.png";
                }
                isstarclicked = false;
            }
        };
        req.send();
        isstarclicked = true;
    }
}*/
function homeclick(){
    document.getElementById("hometab").classList.remove("unselected");
    document.getElementById("hometab").classList.add("selected");
    document.getElementById("hometab").src = "../resources/home_white.png";
    document.getElementById("communitytab").classList.remove("selected");
    document.getElementById("communitytab").classList.add("unselected");
    document.getElementById("communitytab").src = "../resources/community.png";

    document.getElementById("content-home").style.display = "flex";
    document.getElementById("content-community").style.display = "none";
    if (document.getElementById("dropdowncard").style.display == "flex"){
        document.getElementById("dropdowncard").style.display = "none";
        document.getElementById("dropdownback").style.display = "none";
    }
    if (document.getElementById("navmenu").style.display == "flex"){
        document.getElementById("navmenu").style.display = "none";
        document.getElementById("navmenuback").style.display = "none";
    }
}
function communityclick(){
    document.getElementById("hometab").classList.remove("selected");
    document.getElementById("hometab").classList.add("unselected");
    document.getElementById("hometab").src = "../resources/home.png";
    document.getElementById("communitytab").classList.remove("unselected");
    document.getElementById("communitytab").classList.add("selected");
    document.getElementById("communitytab").src = "../resources/community_white.png";

    document.getElementById("content-home").style.display = "none";
    document.getElementById("content-community").style.display = "flex";
    if (document.getElementById("dropdowncard").style.display == "flex"){
        document.getElementById("dropdowncard").style.display = "none";
        document.getElementById("dropdownback").style.display = "none";
    }
    if (document.getElementById("navmenu").style.display == "flex"){
        document.getElementById("navmenu").style.display = "none";
        document.getElementById("navmenuback").style.display = "none";
    }
}
function edit_account(){
    if (document.getElementById("dropdowncard").style.display == "flex"){
        document.getElementById("dropdowncard").style.display = "none";
        document.getElementById("dropdownback").style.display = "none";
    } else {
        document.getElementById("dropdowncard").style.display = "flex";
        document.getElementById("dropdownback").style.display = "block";
    }
}
function dropback(){
    if (document.getElementById("dropdowncard").style.display == "flex"){
        document.getElementById("dropdowncard").style.display = "none";
        document.getElementById("dropdownback").style.display = "none";
    }
}
function account_details(){
    window.location.href = "webbook_account_details.html";
}
function logout(){
    let requestLogout = new XMLHttpRequest();
    requestLogout.open("GET", "https://sasasaia.pythonanywhere.com/logout", true);
    requestLogout.withCredentials = true;
    requestLogout.onreadystatechange = function (){
        if (requestLogout.status == 200 && requestLogout.readyState == 4){
            let response = requestLogout.responseText;
            if (response == "Success"){
                window.location.href = "webbook_login.html";
            }
        }
    }
    requestLogout.send();
}
function menubtnclick(){
    if (document.getElementById("navmenu").style.display == "flex"){
        document.getElementById("navmenu").style.display = "none";
        document.getElementById("navmenuback").style.display = "none";
    } else {
        document.getElementById("navmenu").style.display = "flex";
        document.getElementById("navmenuback").style.display = "block";
    }
}
function navback(){
    if (document.getElementById("navmenu").style.display == "flex"){
        document.getElementById("navmenu").style.display = "none";
        document.getElementById("navmenuback").style.display = "none";
    }
}