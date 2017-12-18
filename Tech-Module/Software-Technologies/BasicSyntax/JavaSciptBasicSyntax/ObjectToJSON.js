function solution(arr){
    let dict={};

    for (let item of arr){
        let args=item.split(" -> ");

        let key=args[0];
        let value=args[1];

        if (isNaN(value)) {
            dict[key]=value;
        }
        else dict[key]=parseInt(value,10);
    }

    var objAsString=JSON.stringify(dict);
    console.log(objAsString);
}