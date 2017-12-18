function solution(arr) {
    let n=Number(arr[0]);
    let x=Number(arr[1]);
    if (n>x) {
        return n/x;
    }
    else return n*x;
}
