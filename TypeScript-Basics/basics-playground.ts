// maps

const nums: number[] = [1, 2, 3, 4];

const doubled = nums.map((e) => e * 2);

//console.log("Doubled number:", doubled);

// filter

const even = nums.filter((e) => e % 2 == 0);

//console.log("Even number:", even);

// reduce

const sumOfAll = nums.reduce((total, e) => total + e, 0);

console.log("sum", sumOfAll);

