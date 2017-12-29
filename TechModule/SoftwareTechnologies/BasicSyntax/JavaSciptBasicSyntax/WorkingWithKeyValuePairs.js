function solution(arr){
    let dict={};
    let keyToFind=arr[arr.length-1];
    for(let i=0; i<arr.length-1;i++){
        let pair=arr[i].split(" ");
        let key=pair[0];
        let value=pair[1];
        dict[key]=value;
    }
    if (dict.hasOwnProperty(keyToFind)){
        console.log(dict[keyToFind]);
    }
    else {
        console.log("None");
    }
}