import requests

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
token = "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"

url = f"https://api.github.com/repos/{owner}/{repo}/contributors"
headers = {"Authorization": f"token {token}"}
response = requests.get(url, headers = headers)
if response.status_code == 200:
    devs = response.json()

    for dev in devs:
        name = dev["login"]
        avatar_url = dev["avatar_url"]
        profile_url = dev["html_url"]
        commits = dev["contributions"]

        dev_obj = Dev(name, avatar_url, profile_url, commits)
        dev_list.append(dev_obj)

for dev in dev_list:
    stats_url = f"https://api.github.com/repos/{owner}/{repo}/stats/contributors"
    stats_response = requests.get(stats_url, headers = headers)

    if stats_response.status_code == 200:
        stats = stats_response.json()

        for dev_stats in stats:

            if dev_stats["author"]["login"] == dev.name:
                insertions = 0
                deletions = 0

                for week in dev_stats["weeks"]:
                    insertions += week["a"]
                    deletions += week["d"]

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