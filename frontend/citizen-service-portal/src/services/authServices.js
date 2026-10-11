var api="http://localhost:5016/api";

export async function Registration(formData) {

    const response = await fetch(
        `${api}/Auth/Registration`,
        {
            method: "POST",
            body: formData
        }
    );

    const data = await response.json();

    if (!response.ok) {
        throw new Error(
            data.message || "Registration failed."
        );
    }

    return data;
}
export async function LoginUser(data) {

    const response = await fetch(
        `${api}/Auth/Login`,
        {
            method: "POST",
            headers: {
            "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        }
    );

    const result = await response.json();

    if (!response.ok) {
        throw new Error(
            data.message || "Login failed."
        );
    }

    return result;
}