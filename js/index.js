const tabs = document.querySelectorAll(".tab");
const tab_containers = document.querySelectorAll(".tab-container");
const contents = document.querySelectorAll(".content");

function mouseEnter(index){
    tabs[index].style.textDecoration = "underline";
}

function mouseLeave(index){
    tabs[index].style.textDecoration = "none";
}

function mouseClick(index){
    tabs.forEach(tab => {
        tab.classList.remove("selected");
    })
    if (index == 0){
        tab_containers[0].style.borderRadius = "16px 16px 0 0";
        tab_containers[1].style.borderRadius = "16px 16px 16px 0";
        tab_containers[2].style.borderRadius = "16px";
        tabs[0].style.borderRadius = "16px 16px 0 0";
        tabs[1].style.borderRadius = "0 0 0 16px";
        tabs[2].style.borderRadius = "0";
    }
    if (index == 1){
        tab_containers[0].style.borderRadius = "16px 16px 0 16px";
        tab_containers[1].style.borderRadius = "16px 16px 0 0";
        tab_containers[2].style.borderRadius = "16px 16px 16px 0";
        tabs[0].style.borderRadius = "0 0 16px 0";
        tabs[1].style.borderRadius = "16px 16px 0 0";
        tabs[2].style.borderRadius = "0 0 0 16px";
    }
    if (index == 2){
        tab_containers[0].style.borderRadius = "16px";
        tab_containers[1].style.borderRadius = "16px 16px 0 16px";
        tab_containers[2].style.borderRadius = "16px 16px 0 0";
        tabs[0].style.borderRadius = "0";
        tabs[1].style.borderRadius = "0 0 16px 0";
        tabs[2].style.borderRadius = "16px 16px 0 0";
    }
    tabs[index].classList.add("selected");
    contents.forEach((content, i) => {
        content.style.display = i == index ? "flex" : "none";
    });
}

window.onload = function() {
    mouseClick(0);
}