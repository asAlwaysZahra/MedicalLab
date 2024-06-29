// let apiRequest = new XMLHttpRequest();
//
// apiRequest.onload = function () {
//     let response = JSON.parse(this.responseText);
//     document.getElementsByClassName('title')[0].onclick = function () {
//         alert(response);
//     };
//     console.log(response);
// };
//
// apiRequest.open('Post', 'https://localhost:44396/api/Users');
// apiRequest.send();

// Get the login and signup forms
const loginForm = document.getElementById('loginForm');
const signupForm = document.getElementById('signupForm');

// Handle login form submission
loginForm.onsubmit = function (event) {
    event.preventDefault(); // Prevent the default form submission
    console.log("kddddddd");
    // Capture the form data
    const username = loginForm.email.value;
    const password = loginForm.password.value;

    // Create the request payload
    const data = JSON.stringify({username, password});
    console.log(data);
    // Create a new XMLHttpRequest object
    const xhr = new XMLHttpRequest();
    xhr.open('GET', 'https://localhost:44396/api/Users/login', true);
    xhr.setRequestHeader('Content-Type', 'application/json;charset=UTF-8');

    // Define a function to handle the response
    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                // Request was successful
                console.log(xhr.responseText);
            } else if (xhr.status === 403) {
                alert("wrong password");
            } else {
                // Handle error
                console.error('Error:', xhr.statusText);
                alert("username not found");
            }
        }
    };

    // Send the request with the payload
    xhr.send(data);
};


// Handle signup form submission
signupForm.addEventListener('submit', function (event) {
    event.preventDefault(); // Prevent the default form submission

    // Capture the form data
    const username = signupForm.email.value;
    const password = signupForm.password.value;
    const confirmPassword = signupForm.confirmPassword.value;
    console.log(username);
    if (password !== confirmPassword) {
        alert("password and confirmation are not the same!");
        return;
    }

    const role = "user";

    // Create the request payload
    const data = JSON.stringify({username, password, role});

    // Create a new XMLHttpRequest object
    const xhr = new XMLHttpRequest();
    xhr.open('POST', 'https://localhost:44396/api/Users', true);
    xhr.setRequestHeader('Content-Type', 'application/json;charset=UTF-8');

    // Define a function to handle the response
    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 201) {
                console.log(xhr.responseText);
            } else {
                console.error('Error:', xhr.statusText);
            }
        }
    };

    xhr.send(data);
});

