import requests, time

class Dev:
    def __init__(self, name, avatar_url, profile_url, commits):
        self.name = name
        self.avatar_url = avatar_url
        self.profile_url = profile_url
        self.commits = commits
        self.insertions = 0
        self.deletions = 0
        self.effective = 0
        self.lines_per_commit = 0

    def update_stats(self, insertions, deletions):
        self.insertions += insertions
        self.deletions += deletions

    def calculate_effective(self) -> int:
        self.effective = self.insertions - self.deletions
        return self.effective

    def calculate_lines_per_commit(self):
        self.lines_per_commit = self.effective // self.commits

dev_list = []
total_efective_lines = 0

owner = "Hyromy"
repo = "BUTTERPOP"

url = f"https://api.github.com/repos/{owner}/{repo}/contributors"
response = requests.get(url)
if response.status_code == 200:
    devs = response.json()

    for dev in devs:
        if dev["login"] == "EmanuelGarciaCapote":
            continue

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

        total_efective_lines += dev.calculate_effective()
        dev.calculate_lines_per_commit()

dev_list.sort(key = lambda dev: dev.name)

with open("README.md", "r", encoding = "utf-8") as f:
    readme = f.read()

part1, _, rest = readme.partition("<!-- stats -->")
_, _, part3 = rest.partition("<!-- /stats -->")

content = "\n".join([
    "\n".join([
        f"\t<tr>",
        f"\t\t<td>",
        f"\t\t\t<a href='{dev.profile_url}' target='_blanck'>",
        f"\t\t\t\t<img src='{dev.avatar_url}' height='128'>",
        f"\t\t\t\t<br>{dev.name}",
        f"\t\t\t</a>",
        f"\t\t</td>",
        f"\t\t<td>{dev.commits}</td>",
        f"\t\t<td>{dev.insertions}</td>",
        f"\t\t<td>{dev.deletions}</td>",
        f"\t\t<td>{dev.effective}</td>",
        f"\t\t<td>{dev.lines_per_commit}</td>",
        f"\t\t<td>{dev.effective / total_efective_lines:.2%}</td>",
        f"\t</tr>"
    ]) for dev in dev_list
])

table = "<table>\n"
table += "\t<tr>\n"
table += "\t\t<td>Desarrollador</td>\n"
table += "\t\t<td>Commits</td>\n"
table += "\t\t<td>Inserciones</td>\n"
table += "\t\t<td>Eliminaciones</td>\n"
table += "\t\t<td>Inserciones efectivas</td>\n"
table += "\t\t<td>Líneas por commit</td>\n"
table += "\t\t<td>Porcentaje de código</td>\n"
table += "\t</tr>\n"

egg = "<br>\n" * 100
egg += "\n![easter egg](img_doc/general/furinaDance.gif)"

data_stats = f"<!-- stats -->\n{table}{content}\n</table>\n{egg}\n<!-- /stats -->"
data = f"{part1}{data_stats}{part3}"

with open("README.md", "w", encoding = "utf-8") as f:
    f.write(data)