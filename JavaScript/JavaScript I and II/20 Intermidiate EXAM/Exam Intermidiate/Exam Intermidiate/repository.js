var name = localStorage.username; // Query a stored value.
name = localStorage["username"]; // Array notation equivalent
if (!name) {
    name = prompt("What is your name?"); // Ask the user a question.
    localStorage.username = name; // Store the user's response.
}
// Iterate through all stored name/value pairs
for (var name in localStorage) { // Iterate all stored names
    var value = localStorage[name]; // Look up the value of each one
    console.log(value);
}


function Student(name, lastname, grade, mark) {
    this.name = name;
    this.lastname = lastname;
    this.grade = grade;
    this.mark = mark;
}

Student.prototype = {
    constructor: Student,
    
};


var students = [
    new Student("pesho", 3,3),
    new Student("gosho", 5, 5),
    new Student("tosho", 4, 4)
];

var courses = {
    "title": "js2",
    "start date": "13-may-2013",
    "total students": 4500,
    "students": students
}

var school = {
    'name': "telerik",
    'location': "sofia",
    'numCourses': 3,
    'specialty': "IT",
    "courses": courses
};


// Put the object into storage
localStorage.setItem('school', JSON.stringify(school));

// Retrieve the object from storage
var retrievedObject = localStorage.getItem('school');

console.log('retrievedObject: ', JSON.parse(retrievedObject));

