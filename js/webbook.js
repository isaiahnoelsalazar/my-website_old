window.onload = function (){
    homeclick();
    let requestSession = new XMLHttpRequest();
    requestSession.open("GET", "https://saiaaaaaa.pythonanywhere.com/", true);
    requestSession.onreadystatechange = function (){
        if (requestSession.status == 200 && requestSession.readyState == 4){
            let response = requestSession.responseText;
            document.write(response);
        } else {
            document.write("Error connecting to server.");
        }
    }
    requestSession.send();
};
/*
if (window.location == "https://openweb.fwh.is/webbook/home/"){
    homeclick();
}
if (window.location == "https://openweb.fwh.is/ow_webbook/webbook.php/#community"){
    communityclick();
}
function newpost(){
    window.location.href = "https://openweb.fwh.is/ow_webbook/webbook_new-post.php";
}
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
    //window.location.href = "https://openweb.fwh.is/ow_webbook/webbook_user-details.php";
}
function logout(){
    //window.location.href = "https://openweb.fwh.is/ow_webbook/logout.php";
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