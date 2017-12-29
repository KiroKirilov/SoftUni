function solution(arr) {
    let num1=Number(arr[0]);
    let num2=Number(arr[1]);
    let num3=Number(arr[2]);
    let numArr=[num1,num2,num3];
    let neg=0;

    if (num1===0 || num2===0 || num3===0) {
        return "Positive";
    }

    for (let item of numArr) {
        if (item<0)neg++;
    }

    if (neg%2===0)return "Positive";
    else return "Negative";
}