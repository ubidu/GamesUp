import React, { useState } from "react";
import AuthService from "../services/auth.service";
import { useNavigate } from "react-router-dom";
import logoimage from "../img/Logo.png";

const Signup = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [username, setUsername] = useState("");
  const [emailError, setEmailError] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [usernameError, setUsernameError] = useState(""); // Dodany hook dla nazwy użytkownika

  const navigate = useNavigate();

  const isEmailFormat = (input) => {
    const emailRegex = /^[a-zA-Z0-9]{3,20}@[a-zA-Z]{2,10}\.[a-zA-Z]{2,3}$/;
    return emailRegex.test(input);
  };

  const isPasswordFormat = (input) => {
    const passwordRegex = /^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,30}$/;
    return passwordRegex.test(input);
  };

  const isUsernameFormat = (input) => {
    // Regex dla nazwy użytkownika - od 3 do 16 znaków, litery (małe i wielkie) oraz cyfry
    const usernameRegex = /^[a-zA-Z0-9]{3,16}$/;
    return usernameRegex.test(input);
    };


  const handleSignup = async (e) => {
    e.preventDefault();

    // Reset errors
    setEmailError("");
    setPasswordError("");
    setUsernameError("");

    if (email.trim() === "") {
      setEmailError("Wpisz adres e-mail.");
      return;
    }

    if (email.trim() !== "" && !isEmailFormat(email)) {
      setEmailError("Podany e-mail jest nieprawidłowy.");
      return;
    }

    if (password.trim() === "") {
      setPasswordError("Wpisz hasło.");
      return;
    }

    if (password.trim() !== "" && !isPasswordFormat(password)) {
      setPasswordError("Podane hasło jest nieprawidłowe.");
      return;
    }

    if (username.trim() === "") {
      setUsernameError("Wpisz nazwę użytkownika.");
      return;
    }

    if (username.trim() !== "" && !isUsernameFormat(username)) {
      setUsernameError("Nazwa użytkownika jest nieprawidłowa.");
      return;
    }

    try {
      await AuthService.signup(email, password, username).then(
        (response) => {
          navigate("/");
          window.location.reload();
        },
        (error) => {
          if (error.response.status === 400) {
            // Check the server response for errors and set the corresponding error states
            if (error.response.data.email) {
              setEmailError(error.response.data.email[0]);
            }
            if (error.response.data.password) {
              setPasswordError(error.response.data.password[0]);
            }
            if (error.response.data.username) {
              setUsernameError(error.response.data.username[0]);
            }
          }
        }
      );
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <section className="h-full bg-black dark:bg-neutral-700 transition">
      <div className="container h-full p-10">
        <div className="g-6 flex h-full flex-wrap items-center justify-center text-neutral-800 dark:text-neutral-200">
          <div className="w-full">
            <div className="block rounded-lg bg-white shadow-lg dark:bg-neutral-800">
              <div className="g-0 lg:flex lg:flex-wrap">
                {/* Left column container*/}
                <div className="px-4 md:px-0 lg:w-6/12">
                  <div className="md:mx-6 md:p-12">
                    {/* Logo */}
                    <div className="text-center">
                      <img
                        src={logoimage}
                        className="mx-auto w-48"
                        alt="logo"
                      />
                      <h4 className="mb-12 mt-1 pb-1 text-xl font-semibold">
                        GamesUp - Portal z grami!
                      </h4>
                    </div>

                    <form onSubmit={handleSignup}>
                      <p className="mb-4">Sign up to your account!:</p>
                      <input
                        className={`flex-grow w-full px-4 py-2 mb-4 mr-4 text-base text-black transition duration-150 ease-in-out bg-white border 
                        ${
                          emailError ? "border-red-500" : "border-gray-300"
                        } rounded-lg appearance-none focus:border-primary-600 focus:outline-none focus:shadow-outline-primary`}
                        type="text"
                        placeholder="email"
                        value={email}
                        onChange={(e) => {
                          setEmail(e.target.value);
                          setEmailError("");
                        }}
                      />
                      {emailError && (
                        <p className="text-red-500 text-sm mb-2">
                          {emailError}
                        </p>
                      )}
                      <input
                        className={`flex-grow w-full px-4 py-2 mb-4 mr-4 text-base text-black transition duration-150 ease-in-out bg-white border 
                        ${
                          passwordError
                            ? "border-red-500"
                            : "border-gray-300"
                        } rounded-lg appearance-none focus:border-primary-600 focus:outline-none focus:shadow-outline-primary`}
                        type="password"
                        placeholder="password"
                        value={password}
                        onChange={(e) => {
                          setPassword(e.target.value);
                          setPasswordError("");
                        }}
                      />
                      {passwordError && (
                        <p className="text-red-500 text-sm mb-2">
                          {passwordError}
                        </p>
                      )}
                      <input
                        className={`flex-grow w-full px-4 py-2 mb-4 mr-4 text-base text-black transition duration-150 ease-in-out bg-white border ${
                          usernameError
                            ? "border-red-500"
                            : "border-gray-300"
                        } rounded-lg appearance-none focus:border-primary-600 focus:outline-none focus:shadow-outline-primary`}
                        type="username"
                        placeholder="username"
                        value={username}
                        onChange={(e) => {
                          setUsername(e.target.value);
                          setUsernameError("");
                        }}
                      />
                      {usernameError && (
                        <p className="text-red-500 text-sm mb-2">
                          {usernameError}
                        </p>
                      )}
                      <button
                        type="submit"
                        className="mb-3 inline-block w-full rounded px-6 pb-2 pt-2.5 text-xs font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_rgba(0,0,0,0.2)] transition duration-150 ease-in-out hover:shadow-[0_8px_9px_-4px_rgba(0,0,0,0.1),0_4px_18px_0_rgba(0,0,0,0.2)] focus:shadow-[0_8px_9px_-4px_rgba(0,0,0,0.1),0_4px_18px_0_rgba(0,0,0,0.2)] focus:outline-none focus:ring-0 active:shadow-[0_8px_9px_-4px_rgba(0,0,0,0.1),0_4px_18px_0_rgba(0,0,0,0.2)]"
                        style={{
                          background:
                            "linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593)",
                        }}
                      >
                        Sign Up
                      </button>
                      <div className="mt-6">
                        <p className="mb-4 text-center text-sm text-neutral-500 dark:text-neutral-400">
                          Or sign up with
                        </p>
                        <div className="flex justify-center space-x-4">
                          {/* Google Login */}
                          <button className="flex items-center px-3 py-2 text-sm font-medium text-white bg-red-600 rounded-lg hover:bg-red-700 focus:outline-none focus:shadow-outline-red">
                            <svg
                              className="w-4 h-4 mr-2 fill-current"
                              viewBox="0 0 48 48"
                              xmlns="http://www.w3.org/2000/svg"
                            >
                              <path
                                fill="#FFF"
                                d="M24 22v4.02h12.08c-.48 2.48-2.05 7.28-6.26 11.42l-3.82-3.1c-1.88-1.53-4.38-3.15-7.25-3.15-4.43 0-8.04 3.6-8.04 8.04s3.6 8.04 8.04 8.04c4.95 0 8.45-5.5 8.9-8.6H24V26.88h-7.06v-4.02H24V16.4H29.6c.2-.92.32-1.88.32-2.88s-.12-1.96-.32-2.88H24V6.1h6.62c3.84 0 7.08 2.48 8.3 5.95l5.36-2.2C40.16 4.48 33.38 2 24 2 13.6 2 6.8 9.32 6.8 18.64s6.8 16.64 17.2 16.64c5.26 0 8.98-3.5 10.54-7.54h-10.54z"
                              />
                            </svg>
                            Google
                          </button>

                          {/* Apple Login */}
                          <button
                            className="flex items-center px-3 py-2 text-sm font-medium text-white bg-black rounded-lg hover:bg-gray-800 focus:outline-none focus:shadow-outline-gray"
                          >
                            <svg
                              className="w-4 h-4 mr-2 fill-current"
                              viewBox="0 0 448 512"
                              xmlns="http://www.w3.org/2000/svg"
                            >
                              <path
                                fill="#FFF"
                                d="M354 288h-74.7c-9.9 0-17.8 7.9-17.8 17.6v100.7c0 9.8 7.9 17.7 17.8 17.7H354c9.9 0 17.8-7.9 17.8-17.7v-100.7c0-9.7-8-17.6-17.8-17.6zm-78.5-24.7v-76.6c0-23.7-13.6-35.7-35.7-35.7-20.3 0-46.2 15-60.3 34.6-8.4 10.3-17.6 26.9-17.6 42.8v75.5H93.1c-9.8 0-17.8 7.9-17.8 17.7v100.7c0 9.8 7.9 17.7 17.8 17.7H159c9.9 0 17.8-7.9 17.8-17.7v-75.7c0-33.1 21.8-51.5 50.5-51.5 10.5 0 21.5 2.5 29.6 5.5z"
                              />
                            </svg>
                            Apple
                          </button>
                        </div>
                      </div>
                    </form>
                  </div>
                </div>

                {/* Right column container with background and description */}
                <div
                  className="flex items-center rounded-b-lg lg:w-6/12 lg:rounded-r-lg lg:rounded-bl-none"
                  style={{
                    background:
                      "linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593)",
                  }}
                >
                  <div className="px-4 py-6 text-white md:mx-6 md:p-12">
                    <h4 className="mb-6 text-xl font-semibold">
                      O portalu GamesUp
                    </h4>
                    <p className="text-sm">
                      Lorem ipsum dolor sit amet, consectetur adipisicing elit,
                      sed do eiusmod tempor incididunt ut labore et dolore magna
                      aliqua. Ut enim ad minim veniam, quis nostrud exercitation
                      ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    </p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default Signup;
