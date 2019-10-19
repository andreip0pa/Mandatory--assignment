let button=document.getElementById("button1");
let i=0;
button.addEventListener("click",function(){
    
let st:string=(<HTMLInputElement>document.getElementById("input1")).value;
let selector=(<HTMLSelectElement>document.getElementById("select1"));
let opt=selector.options[selector.selectedIndex].value;
console.log("bla");
if (opt=="up" && st.length>0){
    document.getElementById("result").innerHTML=st.toUpperCase();
    let table1=<HTMLTableElement>document.getElementById("table1");
    table1.insertRow(i);
    table1.insertRow(i).insertCell(0).innerHTML=st.toUpperCase();
    table1.rows[i].insertCell(1).innerHTML=i.toString();
    i++;
}
else{
    if (st.length>0){
    document.getElementById("result").innerHTML=st.toLowerCase();
    let table1=<HTMLTableElement>document.getElementById("table1");
    table1.insertRow(i);
    table1.insertRow(i).insertCell(0).innerHTML=st.toLowerCase();
    table1.rows[i].insertCell(1).innerHTML=i.toString();
    i++;
    }
}

})

