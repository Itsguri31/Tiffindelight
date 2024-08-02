using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;
using Tiffindelight.Models;
                                        


namespace Tiffindelight.Services
{
    public class FirebaseAuthentication
    {
        private static FirebaseAuthentication _instance;
        public static FirebaseAuthentication Instance => _instance ??= new FirebaseAuthentication();

        private FirebaseAuthClient _client;

        private FirebaseAuthentication()
        {
        }

        private void InitializeFirebase()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = APISettings.APIkey1,
                AuthDomain = APISettings.AuthDomain1,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };

            _client = new FirebaseAuthClient(config);
        }

        public async Task<(bool success, string message)> SignInAsync(string email, string password)
        {
            InitializeFirebase();

            string message;
            var success = false;

            try
            {
                var userCredential = await _client.SignInWithEmailAndPasswordAsync(email, password);
                message = $"Signed in as {userCredential.User.Info.Email}";
                success = true;
            }
            catch (FirebaseAuthHttpException ex)
            {
                message = ex.Reason.ToString() == "Unknown" ? "Incorrect email or password." : ex.Reason.ToString();
            }
            catch (Exception ex)
            {
                message = $"An error occurred: {ex.Message}";
            }

            return (success, message);
        }

        public async Task<(bool success, string message)> SignUpAsync(string email, string password)
        {
            InitializeFirebase();
            string message;
            var success = false;

            try
            {
                var userCredential = await _client.CreateUserWithEmailAndPasswordAsync(email, password);
                message = $"Account created for {userCredential.User.Info.Email}";
                success = true;
            }
            catch (FirebaseAuthHttpException ex)
            {
                message = ex.Reason.ToString();
            }
            catch (Exception ex)
            {
                message = $"An error occurred: {ex.Message}";
            }

            return (success, message);
        }
    }
}
