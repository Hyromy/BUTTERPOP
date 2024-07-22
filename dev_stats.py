import requests, time

class Dev:
    def __init__(self, name, avatar_url, profile_url, commits):
        self.name = name
        self.avatar_url = avatar_url
        self.profile_url = profile_url
        self.commits = commits
        self.insertions = 0
        self.deletions = 0

    def update_stats(self, insertions, deletions):
        self.insertions += insertions
        self.deletions += deletions

dev_list = []

owner = "Hyromy"
repo = "BUTTERPOP"

url = f"https://api.github.com/repos/{owner}/{repo}/contributors"
response = requests.get(url)
if response.status_code == 200:
    devs = response.json()

    for dev in devs:
        name = dev["login"]
        avatar_url = dev["avatar_url"]
        profile_url = dev["html_url"]
        commits = dev["contributions"]

        dev_obj = Dev(name, avatar_url, profile_url, commits)
        dev_list.append(dev_obj)

def get_stats_with_retry(url, retries = 30, wait = 1):
    for _ in range(retries):
        response = requests.get(url)
        if response.status_code == 200 and response.json():
            return response.json()
        time.sleep(wait)

    print(f"Error al obtener las estadísticas de {url}")
    return None

for dev in dev_list:
    stats_url = f"https://api.github.com/repos/{owner}/{repo}/stats/contributors"
    stats = get_stats_with_retry(stats_url)

    if stats:
        for dev_stats in stats:
            if dev_stats["author"]["login"] == dev.name:
                insertions = sum(week["a"] for week in dev_stats["weeks"])
                deletions = sum(week["d"] for week in dev_stats["weeks"])
                dev.update_stats(insertions, deletions)

with open("README.md", "r", encoding = "utf-8") as f:
    readme = f.read()

part1, _, rest = readme.partition("<!-- stats -->")
_, _, part3 = rest.partition("<!-- /stats -->")

content = "\n".join([
    "\n".join([
        f"<h3>",
        f"\t<a href='{dev.profile_url}' target='_blanck'>",
        f"\t\t<img src='{dev.avatar_url}' height='16'>",
        f"\t\t{dev.name}",
        f"\t</a>",
        f"</h3>",
        f"\n**Confirmaciones: {dev.commits}**",
        f"\nInserciones: {dev.insertions}",
        f"\nEliminaciones: {dev.deletions}",
        "\n---\n"
    ]) for dev in dev_list
])

insert = f"<!-- stats -->\n{content}\n<!-- /stats -->"
update = f"{part1}{insert}{part3}"

with open("README.md", "w", encoding = "utf-8") as f:
    f.write(update)