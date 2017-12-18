function solution(arr){
    let dict={};
    let keyToFind=arr[arr.length-1];
    for(let i=0; i<arr.length-1;i++){
        let pair=arr[i].split(" ");
        let key=pair[0];
        let value=pair[1];
        if (dict.hasOwnProperty(key)){
            dict[key].push(value);
        }
        else{
            dict[key]=[];
            dict[key].push(value);
        }
    }
    if (dict.hasOwnProperty(keyToFind)){
        for (let item of dict[keyToFind]){
            console.log(item);
        }
    }
    else {
        console.log("None");
    }
}