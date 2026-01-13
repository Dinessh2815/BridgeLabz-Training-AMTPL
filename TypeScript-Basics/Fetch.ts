// interface User {
//     id : number;
//     name: string;
//     username: string;
//     email: string;
//     phone: string;
//     city: string;
//     role: string;
//     isActive: boolean;
// }

(async function fetchData() : Promise<void>{
    try{
        const response = await fetch("https://mp2b8640ef3f366c030f.free.beeceptor.com/data");
        const data: User[] = await response.json();

        console.log(data[0].isActive)
        data.forEach((e) => {
            console.log(e.email)
        })

        const ids = data.map(user => user.id);
        const ActiveId = data
            .filter(user => user.isActive)
            .map(user => user.id);
        
        console.log("All IDs:", ids);
        console.log("Active IDs:", ActiveId);
   
    }
    catch(e){
            console.log(e)
    }
})()