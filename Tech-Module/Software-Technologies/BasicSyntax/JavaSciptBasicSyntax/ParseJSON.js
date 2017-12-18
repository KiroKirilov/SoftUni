function solution(arr) {
    let myArr=[];
    for (let item of arr){
        myArr.push(JSON.parse(item));
    }

    for (let item of myArr){
        for (let key of Object.keys(item)){
            let keyUp=key.charAt(0).toUpperCase() + key.slice(1);
            console.log(`${keyUp}: ${item[key]}`);
        }
    }
}