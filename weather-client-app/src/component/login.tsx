import React from 'react';
import { useWeatherStore } from '../stores/use-weather-store';
import { Form, Field } from 'react-final-form';
import { useNavigate } from 'react-router-dom';
import { LoginObject } from '../models/models';

export const Login = () => {
    const { authStore } = useWeatherStore();
    const history = useNavigate();

    const submit = async (form: LoginObject) => {
        await authStore.login(form);
        if (authStore.user) {
            history('/home');
        }
    }

    return (
        <Form<LoginObject> onSubmit={submit}
            validate={() => {
                //TO DO Validation in Client
                return {};
            }}>
            {({ handleSubmit }) => (
                <form onSubmit={handleSubmit} >
                    <div>
                        <Field
                            name={'email'}
                            type={'email'}
                            component={'input'}
                            placeholder={'Type your email...'}
                        />
                        <Field
                            name={'password'}
                            type={'password'}
                            component={'input'}
                            placeholder={'Type your password...'}
                        />
                    </div>
                    <button type={'submit'}> Save</button>

                </form>
            )}
        </Form>
    )
}