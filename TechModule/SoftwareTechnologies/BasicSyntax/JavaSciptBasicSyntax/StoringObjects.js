function solution(arr) {
    let myArr=[];
    for (let item of arr){
        let args=item.split(" -> ");
        let name=args[0];
        let age=args[1];
        let grade=args[2];

        myArr.push({
            Name:name,
            Age:age,
            Grade:grade
        });
    }

    for (let st of myArr){
        for (let key of Object.keys(st)){
            console.log(`${key}: ${st[key]}`);
        }
    }
}