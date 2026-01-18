const baseURL = import.meta.env.VITE_API_URL || ''

export async function api(path: string, options?: RequestInit) {
  const res = await fetch(`${baseURL}${path}`, options)
  return res.json()
}
