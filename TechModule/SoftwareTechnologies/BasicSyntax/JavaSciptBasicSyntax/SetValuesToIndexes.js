function solution(arr) {
    let count = Number(arr[0]);
    let myArr = [];
    for (let i = 1; i < arr.length; i++) {
        let temp = arr[i].split(' - ');
        let index = temp[0];
        let value = temp[1];
        myArr[index] = value;
    }

    for (let j = 0; j < count; j++) {
        if (myArr[j] === undefined) {
            console.log(0);
        }
        else {
            console.log(myArr[j]);
        }
    }
}