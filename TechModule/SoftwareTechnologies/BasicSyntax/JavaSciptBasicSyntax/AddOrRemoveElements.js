function solution(arr){
    let myArr=[];
    for (let command of arr) {
        let tokens=command.split(" ");
        let currentCommand=tokens[0];

        if (currentCommand==="add") {
            let item=tokens[1];
            myArr.push(item);
        }

        if (currentCommand==="remove") {
            let index=tokens[1];
            myArr.splice(index,1);
        }
    }

    for (let item of myArr) {
        console.log(item);
    }
}