interface IUser {
  id: number;
  name: string;
  isActive: boolean;
}

class Employees implements IUser {
  public id;
  public name;
  public isActive;

  constructor(id: number, name: string, isActive: boolean) {
    this.id = id;
    this.name = name;
    this.isActive = isActive;
  }

  display = () => {
    console.log(this.id, this.name, this.isActive);
  };
}

class EmployeeWorker extends Employees {
  constructor(id: number, name: string, isActive: boolean, public dept: string) {
    super(id, name, isActive);
    this.dept = dept;
  }
}

const employees: Employees[] = [
  new Employees(1, "Dinessh", true),
  new Employees(2, "Srikesh", false),
];

employees.forEach((e) => {
  e.display();
});

// const users: User[] = [
//     {id: 1, name: "Dinessh", isActive: true},
//     {id: 2, name: "Gaurav", isActive: false}
// ]

// console.log(users.filter((e => e.isActive)).map((e) => e.name));
