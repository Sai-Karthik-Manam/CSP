var api="http://localhost:5016/api";
export async function GetServices() {
    const token = localStorage.getItem("token");

    const response = await fetch(`${api}/Service`, {
        headers: {
            Authorization: `Bearer ${token}`
        }
    });

    if (!response.ok) {
        throw new Error("Failed to fetch services");
    }

    return await response.json();
}